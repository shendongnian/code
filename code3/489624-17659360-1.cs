        private void NotifySccChange()
        {
            foreach (sink in _eventSinks)
            {
                try
                {
                    sink.OnPropertyChanged(MyId, (int)__VSHPROPID.VSHPROPID_StateIconIndex, 0);
                }
                catch (Exception e)
                {
                    SinkIsDead(sink);
                }
            }
        }
