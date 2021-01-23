        private void myElement_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(MyDataType)))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }
        private void myElement_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MyDataType)))
            {
                // do whatever you want do with the dropped element
                MyDataType droppedThingie = e.Data.GetData(typeof(MyDataType)) as MyDataType;
            }
        }
