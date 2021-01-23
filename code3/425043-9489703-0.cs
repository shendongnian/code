    public void UpdateProgressBar(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(UpdateProgressBar), new object[] { value });
                return;
            }
            table1.TableModel.Rows[0].Cells[1].Data = value;
        }
