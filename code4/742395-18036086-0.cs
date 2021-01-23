    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using WindowsFormsApplication9.Annotations;
    
    namespace WindowsFormsApplication9
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                BindingList<Entity> entities = new BindingList<Entity>();
                entities.Add(new Entity {Amount = 10.0, Checked = false, Id = 1});
                entities.Add(new Entity {Amount = 900.0, Checked = false, Id = 2});
                entities.Add(new Entity {Amount = 850.0, Checked = false, Id = 3});
    
                this.dataGridView1.DataSource = entities;
            }
        }
    
        public class Entity : INotifyPropertyChanged
        {
            private bool _bChecked;
            private double _dAmount;
            private int _iId;
    
            public int Id
            {
                get { return this._iId; }
                set
                {
                    if (value == this._iId)
                        return;
    
                    this._iId = value;
                    this.OnPropertyChanged();
                }
            }
    
            public double Amount
            {
                get { return this._dAmount; }
                set
                {
                    if (value == this._dAmount)
                        return;
    
                    this._dAmount = value;
                    this.OnPropertyChanged();
                }
            }
    
            public bool Checked
            {
                get { return this._bChecked; }
                set
                {
                    if (value == this._bChecked)
                        return;
    
                    this._bChecked = value;
                    this.OnPropertyChanged();
                    // Change the value 10 to the value you want to subtract
                    if (value) this.Amount = this._dAmount - 10;
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
  
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
      public sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
      {
        public NotifyPropertyChangedInvocatorAttribute() { }
        public NotifyPropertyChangedInvocatorAttribute(string parameterName)
        {
          ParameterName = parameterName;
        }
    
        public string ParameterName { get; private set; }
      }
