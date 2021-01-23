     UserDetail u = new UserDetail();
            
            u.username = TextBox1.Text;
            u.password = TextBox2.Text;
            TrackToolDataContext data = new TrackToolDataContext();
            data.UserDetails.InsertOnSubmit(u);
            data.SubmitChanges();
