    public class MyDataContextClass{
         public ObservableCollection<PopularVideo> PopVideos;
         public MyDataContextClass(){
              PopVideos = new ObservableCollection<PopularVideo>();
         }
         ...
         private void DownLoadCompleted(object sender, HtmlDocumentLoadCompleted e){
             PopVideos.Clear();
             // Add to pop Videos.
         }
    }
