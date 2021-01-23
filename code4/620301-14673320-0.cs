        private void PopulateDataGridView()
        {
            MyProgressBar.Value = 0;
            MyProgressBar.Maximum = MyList.Count;
            MyBackGroundWorker.RunWorkerAsync();
            MyDataGridView.DataSource = MyList;
        }
