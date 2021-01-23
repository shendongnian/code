        public void UpdateMyLabel(object sender, MyArgs ea)
        {
            this.Invoke(new MethodInvoker(
                delegate()
                {
                    labelControl1.Text = ea.Message;
                }
                ));
        }
