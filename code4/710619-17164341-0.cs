    private void Tab_OnDragOver(object sender, System.Windows.Forms.DragEventArgs e)
            {
                TabPage hover_Tab = HoverTab();
                if (hover_Tab == null)
                    e.Effect = DragDropEffects.None;
                else
                {
                    var drag_tab = e.Data.GetData(e.Data.GetFormats()[0]);
                    if (typeof(TabPage).IsAssignableFrom(drag_tab.GetType()))
                    {
                        e.Effect = DragDropEffects.Move;
    
                        if (hover_Tab == drag_tab) return;
    
                        Rectangle TabRect = GetTabRect(TabPages.IndexOf(hover_Tab));
                        TabRect.Inflate(-3, -3);
                        if (TabRect.Contains(PointToClient(new Point(e.X, e.Y))))
                        {
                            SwapTabPages(drag_tab as TabPage, hover_Tab);
                            SelectedTab = drag_tab as TabPage;
                        }
                    }
                }
            }
