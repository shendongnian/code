        protected void CreateLabels(int num)
        {
            Labels = new Label[num];
            for(int i=0; i<num; i++)
            {
                Labels[i] = new Label();
                this.Controls.Add(Labels[i]);
            }
        }
