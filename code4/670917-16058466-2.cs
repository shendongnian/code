    public abstract class TestBase {
        private string itemType;
        protected TestBase() {
            itemType = ConfigurationManager.AppSettings[
                GetType().Name + ".ItemType";
        }
    }
