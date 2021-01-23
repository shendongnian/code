        public ChildViewModel()
        {
            Messenger.UnRegister(this); //I use reflection and Attributes to register/Unregister you can do it normally
            Messenger.Register(this);
            if (ChildData== null)
            {
                Messenger.NotifyColleagues<object>(
                    MessengerMessages.GET_CHILD_DATA,ChildData);
            }            
        }
        [MessengerMessageSink(MessengerMessages.SEND_CHID_DATA,
            ParameterType = typeof (CHILD_DATA))]
        protected void Set_Child_DATA(ChildData childData)
        {
            if (childData!= null)
            {
                //Do Something              
            }
        }
