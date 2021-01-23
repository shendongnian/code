     protected virtual void figureMouseMove(object sender, MouseEventArgs e)
     {
         if (mouseDown)
         {
             if (inGroup)
             {   // raising the event
                  if (this.GroupMoveEvent != null)
                   GroupMoveEvent(this, new GroupMoveEventArgs(
                                   GroupMoveEventArgs.Action.Move,
                                   Parent.PointToClient(Control.MousePosition).X,
                                   Parent.PointToClient(Control.MousePosition).Y));
             }
          }
        }  
