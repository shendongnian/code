      public static void EmailShopDrawingAndDoorSchedule(IElevation elevation, string fromEmail, string toEmail)
        {
            ThreadPool.QueueUserWorkItem(t =>
                           {
                               using (Bitmap printCanvas = ShopDrawing.Merger.MergeElevationAndDoor(elevation, RotateFlipType.Rotate90FlipNone))
                               {
                                   using (var ms = new MemoryStream())
                                   {
                                       printCanvas.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                       ms.Position = 0;
                                       using (MailMessage mm = new MailMessage(new MailAddress(fromEmail), new MailAddress(toEmail)))
                                       {
                                           mm.Subject = "[Project: " + elevation.ProjectName + "] " + " Shop drawings for " + elevation.Name;
                                           mm.Body = "Your shop drawings are attached to this email in reference to Project: " + elevation.ProjectName + " -> Elevation: " + elevation.Name;
                                           using (Attachment at = new Attachment(ms, elevation.Name + ".png", "image/png"))
                                           {
                                               mm.Attachments.Add(at);
                                               using (var smtp = new SmtpClient())
                                               {
                                                   smtp.Send(mm);
                                               };
                                           }
                                       };
                                   };
                               };
                           });
        }
