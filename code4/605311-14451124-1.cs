    using System;
    // 2. Drag button tutorial
    namespace DragButton
    {
        public class App: Gtk.Window
        {
            enum StatusType
            {
                Checked,
                NotChecked
            }
            Gtk.Button btnDrag;
            Gtk.Label lblDrop;
            bool isChecked;
            Gtk.Statusbar sBar;
            public App (): base("Drag And Drop Complete")
            {
                this.SetDefaultSize (250, 200);
                this.SetPosition (Gtk.WindowPosition.Center);
                this.DeleteEvent += OnTerminated;
                
                this.isChecked = false;
                this.sBar = new Gtk.Statusbar ();
                sBar.Push ((uint)StatusType.NotChecked, "Not checked");
                this.btnDrag = new Gtk.Button ("Drag here");
                Gtk.Drag.SourceSet
                    (this.btnDrag,
                     Gdk.ModifierType.Button1Mask
                     | Gdk.ModifierType.Button3Mask,
                     null,
                     Gdk.DragAction.Copy | Gdk.DragAction.Move);
                this.btnDrag.DragDataGet
                    += new Gtk.DragDataGetHandler
                        (HandleSourceDragDataGet);
                this.btnDrag.DragDataDelete
                    += new Gtk.DragDataDeleteHandler
                        (HandleSourceDragDataDelete);
                
                // set drop label as destination
                this.lblDrop = new Gtk.Label ("Drop here");
                Gtk.Drag.DestSet (this.lblDrop, 0, null, 0);
                this.lblDrop.DragMotion
                    += new Gtk.DragMotionHandler
                        (HandleTargetDragMotion);
                this.lblDrop.DragDrop
                    += new Gtk.DragDropHandler
                        (HandleTargetDragDrop);
                this.lblDrop.DragDataReceived
                    += new Gtk.DragDataReceivedHandler
                        (this.HandleTargetDragDataReceived);
                this.lblDrop.DragDrop
                    += new Gtk.DragDropHandler
                        (this.HandleStatBarDragDrop);
                Gtk.MenuBar bar = new Gtk.MenuBar ();
                Gtk.MenuItem item = new Gtk.MenuItem ("File");
                Gtk.Menu menu = new Gtk.Menu ();
                item.Submenu = menu;
                bar.Append (item);
                // accel key
                Gtk.AccelGroup ag = new Gtk.AccelGroup ();
                this.AddAccelGroup (ag);
                item = new Gtk.MenuItem ("Quit");
                item.Activated += OnTerminated;
                item.AddAccelerator
                    ("activate", ag, new Gtk.AccelKey
                     (Gdk.Key.Q, Gdk.ModifierType.ControlMask, 
                     Gtk.AccelFlags.Visible));
                menu.Append (item);
                Gtk.VBox vbox = new Gtk.VBox();
                vbox.PackStart (bar, false, false, 0);
                Gtk.HBox hbox = new Gtk.HBox ();
                hbox.PackStart (this.btnDrag, true, true, 0);
                hbox.PackStart (this.lblDrop, true, true, 0);
                vbox.PackStart (hbox, true, true, 0);
                vbox.PackStart (sBar, false, false, 0);
                this.Add (vbox);
                this.ShowAll ();
            }
            void OnTerminated(object sender, EventArgs args)
            {
                Gtk.Application.Quit ();
            }
            void HandleSourceDragDataGet
                (object sender, Gtk.DragDataGetArgs args)
            {
                Console.WriteLine ("Source Drag Data Get");
                args.SelectionData.Text = "I'm data!";
            }
            void HandleSourceDragDataDelete
                (object sender, Gtk.DragDataDeleteArgs args)
            {
                Console.WriteLine ("Source Drag Data Delete");
                Console.WriteLine ("Delete the data!");
            }
            void HandleTargetDragMotion
                (object sender, Gtk.DragMotionArgs args)
            {
                Gdk.Drag.Status (args.Context,
                                 args.Context.SuggestedAction,
                                 args.Time);
                args.RetVal = true;
            }
            void HandleTargetDragDrop
                (object sender, Gtk.DragDropArgs args)
            {
                Console.WriteLine ("drop");
                if (args.Context.Targets.Length != 0) {
                    Gtk.Drag.GetData
                        ((Gtk.Widget)sender, args.Context,
                         args.Context.Targets[0], args.Time);
                    args.RetVal = true;
                }
                
                args.RetVal = false;
            }
            void HandleTargetDragDataReceived
                (object sender, Gtk.DragDataReceivedArgs args)
            {
                Console.WriteLine ("received");
                if (args.SelectionData.Length >= 0
                    && args.SelectionData.Format == 8) 
                {
                    Console.WriteLine ("Hi!");
                    
                    Gtk.Drag.Finish (args.Context, true, false, args.Time);
                }
                Gtk.Drag.Finish (args.Context, false, false, args.Time);
            }
            void HandleStatBarDragDrop
                (object sender, Gtk.DragDropArgs args)
            {
                isChecked = !isChecked;
                if (isChecked)
                    sBar.Push ((uint)StatusType.Checked, "Checked");
                else
                    sBar.Pop ((uint)StatusType.Checked);
            }
            public static void Main (string[] args)
            {
                Gtk.Application.Init ();
                new App ();
                Gtk.Application.Run ();
            }
        }
    }
