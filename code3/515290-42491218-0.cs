            private void RepositoryItemCheckEdit1_EditValueChanged(object sender, System.EventArgs e)
            {
                gridView3.PostEditor();
                var isNoneOfTheAboveChecked = false;
                for (int i = 0; i < gridView3.DataRowCount; i++)
                {
                    if ((bool) (gridView3.GetRowCellValue(i, "NoneOfTheAbove")) && (bool) (gridView3.GetRowCellValue(i, "Answer")))
                    {
                        isNoneOfTheAboveChecked = true;
                        break;
                    }
                }
                if (isNoneOfTheAboveChecked)
                {
                    for (int i = 0; i < gridView3.DataRowCount; i++)
                    {
                        if (!((bool)(gridView3.GetRowCellValue(i, "NoneOfTheAbove"))))
                        {
                            gridView3.SetRowCellValue(i, "Answer", false);
                        }
                    }
                }
            }
