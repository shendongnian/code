        public class Login { public DateTime loginDate { get; set; } public string user { get; set; } }
        [TestMethod()]
        public void foo()
        {
            var logins = new[] { 
              new Login() { loginDate = new DateTime(2013, 5, 1), user = "u1" }
            , new Login() { loginDate = new DateTime(2013, 5, 2), user = "u1" }
            , new Login() { loginDate = new DateTime(2013, 5, 3), user = "u2" }
            , new Login() { loginDate = new DateTime(2013, 5, 4), user = "u2" }
            
            };
            var lastLogins = logins.Where(l =>
                        l.loginDate == logins.Where(ll => ll.user == l.user)
                                             .Max(ll => ll.loginDate)
            ).ToList();
        }
