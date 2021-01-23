     private void grdGrid_MouseDown(object sender, MouseEventArgs e)
            {
                posImGrid = null;
    
                GridHitInfo hitInfo = grvView.CalcHitInfo(new Point(e.X, e.Y));
    
                if (Control.ModifierKeys != Keys.None)
                {
                    return;
                }
    
                if ((e.Button == System.Windows.Forms.MouseButtons.Left) &&
                    (hitInfo.InRow) &&
                    (hitInfo.HitTest != GridHitTest.RowIndicator))
                {
                    posImGrid = hitInfo;
                }
            }
    
            private void grdGrid_MouseMove(object sender, MouseEventArgs e)
            {
                if ((e.Button == System.Windows.Forms.MouseButtons.Left) &&
                    (posImGrid != null))
                {
                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(posImGrid.HitPoint.X - dragSize.Width / 2,
                                                                 posImGrid.HitPoint.Y - dragSize.Height / 2), dragSize);
    
                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        grvView.GridControl.DoDragDrop(GetDragData(grvView), DragDropEffects.All);
                        posImGrid = null;
                    }
                }
            }
            private SchedulerDragData GetDragData(GridView view)
        {
            Appointment termin = Storage.CreateAppointment(AppointmentType.Normal);
            clsMeineKlasse tempObjekt = (clsMeineKlasse)grvView.GetFocusedRow();
            termin.Description = tempObjekt.Beschreibung;
            termin.Subject = tempObjekt.Bezeichnung;
            termin.Duration = TimeSpan.FromHours(8);
            SchedulerDragData sdd = new SchedulerDragData(termin);
            return sdd;
        }
