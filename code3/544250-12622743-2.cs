    public class WorldViewModel : INotifyPropertyChanged
    {
       private BindingList<Person> m_People;
       public BindingList<Person> People
       {
          get { return m_People; }
          set
          {
             if(value != m_People)
             {
                m_People = value;
                if(m_People != null)
                {
                   m_People.ListChanged += delegate(object sender, ListChangedEventArgs args)
                   {
                      OnPeopleListChanged(this);
                   };
                }
                RaisePropertyChanged("People");
             }
          }
       }
    
       private static void OnPeopleListChanged(WorldViewModel vm)
       {
          vm.RaisePropertyChanged("People");
       }
       public event PropertyChangedEventHandler PropertyChanged;
       void RaisePropertyChanged(String prop)
       {
          PropertyChangedEventHandler handler = this.PropertyChanged;
          if (handler != null)
          {
              handler(this, new PropertyChangedEventArgs(prop));
          }
       }
    }
