    RepositoryItemCheckEdit edit;
    CheckEditViewInfo editInfo;
    CheckEditPainter editPainter;
    //...
        edit = new RepositoryItemCheckEdit();
        editInfo = (CheckEditViewInfo)edit.CreateViewInfo();
        editPainter = (CheckEditPainter)edit.CreatePainter();
    }
    Hashtable checkedRows = new Hashtable();
    Hashtable editorRects = new Hashtable();
    void gvWorkspaces_Click(object sender, EventArgs e) {
        GridView view = (GridView)sender;
        Point pt = view.GridControl.PointToClient(Control.MousePosition);
        GridHitInfo info = view.CalcHitInfo(pt);
        if(info.InRow) {
            Rectangle editorRect = (Rectangle)editorRects[info.RowHandle];
            if(editorRect.Contains(pt)) {
                object value = checkedRows[info.RowHandle]; 
                if(value == null)
                    checkedRows[info.RowHandle] = true;
                else checkedRows.Remove(info.RowHandle);
                view.GridControl.Invalidate(editorRect);
            }
        }
    }
    void gvWorkspaces_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e) {
        e.Painter.DrawObject(e.Info);
        GridGroupRowInfo info = (GridGroupRowInfo)e.Info;
        Rectangle checkRect = info.ButtonBounds;
        checkRect.X = e.Bounds.Right - checkRect.Width - 4;
        DrawCheckEdit(e.Graphics, checkRect, checkedRows[e.RowHandle] != null);
        editorRects[e.RowHandle] = checkRect; // cache rectangle
        e.Handled = true;
    }
    void DrawCheckEdit(Graphics graphics, Rectangle r, bool cheched) {
        editInfo.EditValue = cheched;
        editInfo.Bounds = r;
        editInfo.CalcViewInfo(graphics);
        using(GraphicsCache cache = new GraphicsCache(graphics)) {
            editPainter.Draw(new ControlGraphicsInfoArgs(editInfo, cache, r));
        }
    }
