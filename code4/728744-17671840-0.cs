        private void Form1_Load(object sender, EventArgs e)
        {                       
            Boolean someCondition = true; //whatever check you're doing
            if (someCondition)
            {
                MessageBox.Show("Some Condition Met");
                this.Close();
            }
            else
            {
                this.InitialiseTheFormEtc();
            }
        }
