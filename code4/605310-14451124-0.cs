    using System;
    using System.Collections;
    using System.Collections.Generic;
    // 1. Drop file tutorial
    namespace DropFile
    {
        public class App: Gtk.Window
        {
            Gtk.Label lbldrop;
            public App (): base ("Drop file")
            {
                this.SetDefaultSize (250, 200);
                this.SetPosition (Gtk.WindowPosition.Center);
                this.DeleteEvent += OnTerminated;
                this.lbldrop = new Gtk.Label ("Drop here!");
                Gtk.Drag.DestSet (this.lbldrop, 0, null, 0);
                this.lbldrop.DragDrop
                    += new Gtk.DragDropHandler
                        (OnLabelDragDrop);
                this.lbldrop.DragDataReceived
                    += new Gtk.DragDataReceivedHandler
                        (OnLabelDragDataReceived);
                Gtk.VBox vbox = new Gtk.VBox ();
                vbox.PackStart (this.lbldrop, true, true, 0);
                this.Add (vbox);
                this.ShowAll ();
            }
            void OnLabelDragDrop (object sender, Gtk.DragDropArgs args)
            {
                Gtk.Drag.GetData
                    ((Gtk.Widget)sender, args.Context,
                     args.Context.Targets[0], args.Time);
            }
            void OnLabelDragDataReceived
                (object sender, Gtk.DragDataReceivedArgs args)
            {
                if (args.SelectionData.Length > 0
                    && args.SelectionData.Format == 8) {
                    byte[] data = args.SelectionData.Data;
                    string encoded = System.Text.Encoding.UTF8.GetString (data);
                    // I don't know what last object is,
                    //  but I tested and noticed that it is not
                    //  a path
                    List<string> paths
                        = new List<string> (encoded.Split ('\r', '\n'));
                    paths.RemoveAll (string.IsNullOrEmpty);
                    paths.RemoveAt (paths.Count-1);
                    for (int i=0; i<paths.Count; ++i)
                    {
                        Console.WriteLine ("Path {0}: {1}", i, paths[i]);
                    }
                }
            }
            bool Test (string str)
            {
                return true;
            }
            void OnTerminated (object sender, EventArgs args)
            {
                Gtk.Application.Quit ();
            }
            public static void Main (string[] args)
            {
                Gtk.Application.Init ();
                new App ();
                Gtk.Application.Run ();
            }
        }
    }
