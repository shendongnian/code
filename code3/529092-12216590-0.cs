        class UpdatableDocumentPanel : DocumentPanel
        {
            public int myinterval { get; set; }//the individual update interval (300ms for example)
            int currentinterval;
            public void Update()
            {
                currentinterval++;
                if (myinterval == currentinterval)
                {
                    currentinterval = 0;
                    UpdateMyPanelMethod();
                }
            }
        }
