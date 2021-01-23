     public class When_disposed_is_called()
     {
        public void The_object_should_be_disposed()
        {
           var disposableObjects = someContainer.GetAll<IDisposable>();
           disposableObjects.ForEach(obj => obj.Dispose());
           Assert.False(disposableObject.Any(obj => obj.IsDisposed == false));
        }
     }
