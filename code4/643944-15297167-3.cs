    interface ICommunication
    {
    }
    interface ICommunicationCallback<T>
    {
    }
    class AbstractCommunicationCallback<T> : ICommunicationCallback<T>
    {
       
    }
    abstract  class AbstractCommunication : ICommunication
    {
        private ICommunicationCallback<ICommunication> callback = null;
        public void registerCommunicationCallback<T>(ICommunicationCallback<T> callback) where T : ICommunication
        {
            this.callback = (ICommunicationCallback<ICommunication>)callback; //<--DOESNT WORK
        }
    }
    class Communication : AbstractCommunication { 
    }
