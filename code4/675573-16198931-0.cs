    protected override bool ProcessDialogKey(Keys keyData)
            {
                int selectionIndex = pBoundsCollection.IndexOf(pSelection);
                if (keyData == Keys.Tab)
                {
                    while (selectionIndex++ <= pBoundsCollection.Count)
                    {
                        if (selectionIndex >= pBoundsCollection.Count)
                        {
                            selectionIndex = 0;
                            pSelection = (CMRField)pBoundsCollection[selectionIndex];
                            Refresh();
                            break;
                        }
                        if (((CMRField)pBoundsCollection[selectionIndex]).IsSelectable)
                        {
                            pSelection = (CMRField)pBoundsCollection[selectionIndex];
                            Refresh();
                            return false;
                        }
                    }
                }
                return base.ProcessDialogKey(keyData);
            }
