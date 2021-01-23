    public class PageCollectionTemplate : INotifyPropertyChanged {
   
       private static readonly void m_Instance=new PageCollectionTemplate();
       private int m_templateWidth;
       public static PageCollectionTemplate Instance {
         get { return m_Instance; }
       }
       public  int TemplateWidth {
            get { return m_templateWidth; }
    
            set 
            { 
                if (m_templateWidth == value) return;
                m_templateWidth = value;                
                OnPropertyChanged("TemplateWidth");
            }
        }
        // Do same for template height...
       protected void OnPropertyChanged(string propertyName) {
         var handler=PropertyChanged;
         if (handler!=null) handler(this,new PropertyChangedEventArgs(propertyName));
      }
      public event PropertyChangedEventHandler PropertyChanged;
    
    }
