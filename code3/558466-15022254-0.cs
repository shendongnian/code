            private void button1_Click(object sender, EventArgs e)
        {
            Class1 objc ;
             objc = new Class1();
            objc.empName = "name1";
            checkobj( objc);
            MessageBox.Show(objc.empName);  //propert value changed; but object itself did not change
        }
        private void checkobj ( Class1 objc)
        {
            objc.empName = "name 2";
            Class1 objD = new Class1();
            objD.empName ="name 3";
            objc = objD ;
            MessageBox.Show(objc.empName);  //name 3
        }
