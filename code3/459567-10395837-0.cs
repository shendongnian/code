    public class SomeService
    {
        ObservableCollection<ModelA> modelsA;
    
        public ObservableCollection<ModelA> ModelsA
        {
            get
            {
                if(modelsA == null)
                {
                   modelsA = new ObservableCollection<ModelA>();
                   //fill with data...
             
                   modelsA.CollectionChanged += ModelsAChanged;
    
                   foreach (ModelA A in modelsA)
                       A.ModelsB.CollectionChanged += ModelsBChanged;
                }
                return modelsA;
            }
        }
        private void ModelsAChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //remember to subscribe to ModelsB in any new ModelA instance that get added 
            //to the modelsA collection too, and unsubscribe when they get removed.
        }
        private void ModelsBChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
          
        }
    }
