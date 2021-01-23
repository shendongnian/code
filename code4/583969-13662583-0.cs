        private void button2_Click(object sender, EventArgs e)
        {
            if (iCount == 0)
            {
                iTemp = 20;
                iCount++;
            }
            iTemp = iTemp - 1;
            MessageBox.Show(iTemp.ToString());
        }
    }
