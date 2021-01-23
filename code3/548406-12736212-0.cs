     List<int> MyList = new List<int>();
                MyList.Add(1);
                MyList.Add(2);
                MyList.Add(3);
                MyList.Add(4);
                MyList.Add(5);
                MyList.Add(6);
    
                var m = string.Join(",", MyList);
    
                MessageBox.Show(m.ToString());
