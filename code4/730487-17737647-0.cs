            if (Char.IsLetter(e.KeyChar))
            {
                for (int i = 0; i < (dataGridView1.Rows.Count); i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString().StartsWith(e.KeyChar.ToString(), true, CultureInfo.InvariantCulture))
                    {
                        if (lastKey == '\0')
                        {
                            lastKey = e.KeyChar;
                            if (lastKey == e.KeyChar && lastIndex < i)
                            {
                                int last = lastIndex;
                                lastIndex = i;
                                lastKey = e.KeyChar;
                                this.clearGrid(last);
                                dataGridView1.Rows[i].Cells[0].Selected = true;
                                return;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (lastKey != e.KeyChar)
                            {
                                int last = lastIndex;
                                lastIndex = i;
                                lastKey = e.KeyChar;
                                this.clearGrid(last);
                                dataGridView1.Rows[i].Cells[0].Selected = true;
                                return;
                            }
                            else
                            {
                                // int last = lastIndex;
                                if (lastKey == e.KeyChar && lastIndex < i)
                                {
                                    int last = lastIndex;
                                    lastIndex = i;
                                    lastKey = e.KeyChar;
                                    this.clearGrid(last);
                                    dataGridView1.Rows[i].Cells[0].Selected = true;
                                    return;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        private void clearGrid(int l)
        {
            dataGridView1.Rows[l].Cells[0].Selected = false;
        }
