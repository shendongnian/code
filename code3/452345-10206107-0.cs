        public void ProcessRequest(HttpContext context)
        {
           try
            {
                byte[] Attachement = (byte[])AttachementDAL.ReadAttachement(int.Parse(context.Session["attch_serial"].ToString())).Rows[0]["attach_content"];
                context.Response.Clear();
                context.Response.ContentType = "application/msword";
                foreach(byte b in Attachement)
                {
                    context.Response.OutputStream.WriteByte(b);
                }
                context.Response.OutputStream.Flush();
            }
            catch (Exception ee)
            {
            }
        }
