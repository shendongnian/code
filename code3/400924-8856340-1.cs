        public ParentViewModel()
        {
            Messenger.UnRegister(this); //I use reflection and Attributes to register/Unregister you can do it normally
            Messenger.Register(this);            
        }
        [MessengerMessageSink(MessengerMessages.GET_CHILD_DATA,
            ParameterType = typeof (CHILD_DATA))]
        protected void Send_Child_DATA(Object obj)
        {
                            Messenger.NotifyColleagues<object>(
                    MessengerMessages.SEND_CHILD_DATA,ChildData);
        }
