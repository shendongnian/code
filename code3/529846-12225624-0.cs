     private void Form1_Load(object sender, EventArgs e)
        {
            MyFirstSwitch(true);
            //c=console.readline();
            string yup;
            switch (yup)
            {
                case "y":
                    MyFirstSwitch(false);
                    break;
                case "n":
                    //Exit
                    break;
            }
        }
        private void MyFirstSwitch(bool check)
        {
            switch (check)
            {
                case true:
                    //Do some thing hereZ
                    break;
                case false:
                    //Do some thing hereZ
                    break;
            }
        }
