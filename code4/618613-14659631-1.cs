    void c1FlexGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ht = c1FlexGrid1.HitTest();
 
            if (ht.Row!=-1)
            {
                MessageBox.Show("Click on row no--" + ht.Row);
                //do something
            }
        }
