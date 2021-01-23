            Thread notifyThread = new Thread(delegate()
            {
                foreach (CallBackSubscriber subscriber in this.CallBackSubscribers)
                {
                    subscriber.CallBackProxy.CADManagerRegistrationNotification(regCADManager.ID, state);
                }
            });
