        for (int i = 0; i < deptCount; i++)
        {
            Button b = ActiveForm.Controls["btnDept" + i.ToString()] as Button;
            if (b != null)
            {
                if (count == -1)
                {
                    b.Visible = true;
                }
                else
                {
                    // etc.
                }
            }
        }
