        public class Graph : PictureBox
        {
            ObservableCollection<Curve> Curves;
            //And some code to take care of drawing the curves
    
            public Graph(){
             Cureves.OnCollectionChanges +=  colletionChangedEvent;
            }
            collectionChangedEvent(object sender, e args){
              redrawGraph();
            }
    
        }
