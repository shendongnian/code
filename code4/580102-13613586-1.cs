    namespace WPF.MVVMBase
    {
        /// <summary>
        /// Property Decorator that marks the Property as Observable. This is used by the EditableObject class to determine for which properties to raise the Property Changed method
        /// </summary>
        public class ObservablePropertyAttribute : System.Attribute{};
    
        /// <summary>
        /// Extends the ObservableObject class. EditableObject implements methods which are used to edit the object as well as raise the Property Changed events.
        /// </summary>
        /// <typeparam name="T">The Struct for the Editable Object</typeparam>
        public abstract class EditableObject<T> : ObservableObject
        {
            #region Private Variables
    
            bool _IsEditEnabled = false;
            bool _IsSelected = false;
    
            protected T _editData;
            protected T _backupData;
    
            #endregion
    
            #region Public Properties
    
            /// <summary>
            /// Controls if the Edit is enabled on the Editable Object
            /// </summary>
            public bool IsEditEnabled
            {
                get
                {
                    return _IsEditEnabled;
                }
                protected set
                {
                    _IsEditEnabled = value;
                    this.RaisePropertyChanged("IsEditEnabled");
                }
            }
    
            /// <summary>
            /// Determines weather the object is Selected. Used with Lists
            /// </summary>
            public bool IsSelected
            {
                get
                {
                    return _IsSelected;
                }
                set
                {
                    _IsSelected = value;
                    this.RaisePropertyChanged("IsSelected");
                }
            }
    
            #endregion
    
            #region Constructor
    
            public EditableObject()
            {
                //Create an instance of the object that will hold the data.
                _editData = Activator.CreateInstance<T>();
            }
    
            #endregion
    
            #region Methods
    
            #region Abstract Methods
    
            /// <summary>
            /// Handle the object saving. This is called by the SaveChanges method.
            /// </summary>
            /// <returns>Indicates if the object was saved successfully</returns>
            protected abstract bool SaveObject();
    
            /// <summary>
            /// Handle the object remove. This is called by the Remove method.
            /// </summary>
            /// <returns>Indicates if the object was removed successfully</returns>
            protected abstract bool RemoveObject();
    
            #endregion
    
            /// <summary>
            /// Begin editing the object. Sets the IsEditEnabled to true and creates a backup of the Data for restoring.
            /// </summary>
            public void BeginEdit()
            {
                IsEditEnabled = true;
                _backupData = Mapper.DynamicMap<T>(_editData);
            }
    
            /// <summary>
            /// Discard any changes made to the object. Set the IsEditEnabled flag to false and restore the data from the Backup.
            /// </summary>
            public void DiscardChanges()
            {
                _editData = _backupData;
                IsEditEnabled = false;
    
                RaisePropertiesChanged(this);
            }
    
            /// <summary>
            /// Save the changes made to the object. Calls the SaveObject method. If save was successfull IsEditEnabled is set to false and backup data is set to current data.
            /// </summary>
            /// <returns>Indicates if the object was saved successfully</returns>
            public bool SaveChanges()
            {
                bool isSaveSuccessfull = SaveObject();
    
                if (isSaveSuccessfull == true)
                {
                    _backupData = _editData;
    
                    IsEditEnabled = false;
    
                    RaisePropertiesChanged(this);
                }
    
                return isSaveSuccessfull;
            }
    
            public bool Remove()
            {
                bool isRemoveSuccessfull = RemoveObject();
                return isRemoveSuccessfull;
            }
    
            /// <summary>
            /// Raises ObservableObject Property Changed for all the decorated methods in the given object so that the interface can refresh accordingly.
            /// </summary>
            /// <param name="baseObject"></param>
            public void RaisePropertiesChanged(object baseObject)
            {
                PropertyInfo[] properties = baseObject.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    object[] attributes = property.GetCustomAttributes(true);
    
                    bool isObservableProperty = (from attribute in attributes
                                                 where attribute is ObservablePropertyAttribute
                                                 select attribute).Count() > 0;
    
                    if (isObservableProperty)
                    {
                        RaisePropertyChanged(property.Name);
                    }
                }
            }
    
            #endregion
        }
    }
