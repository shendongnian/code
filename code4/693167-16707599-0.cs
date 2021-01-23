        /// <summary>
        /// Custom datagridview to enable double buffering
        /// </summary>
        public class MyDataGridView : DataGridView
        {
            public MyDataGridView()
            {
                DoubleBuffered = true;
            }
        }
