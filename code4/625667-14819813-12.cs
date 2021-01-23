    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using tryout13022013.PersonViewModels;
    using System.ComponentModel;
    using tryout13022013.DetailsViewModel;
    using tryout13022013.PersonModel;
    
    namespace tryout13022013
    {
        public class MainViewModel
        {
            private PersonViewModel _subPerson = new PersonViewModel();
            public PersonViewModel SubPerson
            {
                get 
                {
                    return _subPerson;
                }
                set
                {
                    if (_subPerson != value)
                    {
                        _subPerson = value; OnPropertyChanged("SubPerson");
                        
                    }
                }
            }
    
    
            private PersonDetailsViewModel _subDetail = new PersonDetailsViewModel();
            public PersonDetailsViewModel SubDetail
            {
                get { return _subDetail; }
                set 
                {
                    _subDetail = value; OnPropertyChanged("SubDetail");
                }
    
            }
    
            private Person _selectedPerson;
            public Person SelectedPerson
            {
                get { return _selectedPerson; }
                set {
                    if (_selectedPerson != value)
                    {
                        _selectedPerson = value;
                        OnPropertyChanged("SelectedPerson");
    					OnPropertyChanged("SelectedPersonDetail");	//In this way when Change the Selected Person, the Selected Detail will be changed again...
                        //if (this.SelectedPerson != null && this.SubDetail != null)
                        //{
                           // I dont know how to call the PersonDetailsViewModel class like a method here in order to load its data. kindly help
                           //this.SubDetail.MethodforLoadingPersonDetails(this.SelectedPerson);
                        //}
                    }
                }
    
            }
    		
            public PersonDetails SelectedPersonDetail
            {
                get
    			{
    			    if (SubDetail == null || SelectedPerson ==null)
    					return  null;
    				return SubDetails.FirstOrDefault(detail => detail.PersonID == SelectedPerson.PersonID);
    			}           
    
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string propertyname)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
