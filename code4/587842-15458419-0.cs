    public class CustomConfigSessionFactory : JschConfigSessionFactory
    {
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        protected override void Configure(OpenSshConfig.Host hc, Session session)
        {
            var config = new Properties();
            config["StrictHostKeyChecking"] = "no";
            config["PreferredAuthentications"] = "publickey";
            session.SetConfig(config);
            var jsch = this.GetJSch(hc, FS.DETECTED);
            jsch.AddIdentity("KeyPair", Encoding.UTF8.GetBytes(PrivateKey), Encoding.UTF8.GetBytes(PublicKey), null);
        }
    }
