            for (int i = 0; i < dgTest.Rows.Count; i++)
            {
                if (dgTest.Rows[i].Cells[0].Value.ToString() == "search")
                {
                    dgTest.Rows[i].Selected = true;
                    dgTest.Rows[i].Visible = true;
                }
                else
                {
                    dgTest.Rows[i].Visible = false;
                    dgTest.Rows[i].Selected = false;
                }
            }
