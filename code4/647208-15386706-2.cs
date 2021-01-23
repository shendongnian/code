    using System;
    namespace Demo
    {
        public interface ISuspendableNotifications
        {
            void SuspendNotifications();
            void ResumeNotifications();
        }
        public sealed class NotificationSuspender: IDisposable
        {
            public NotificationSuspender(ISuspendableNotifications suspendableNotifications)
            {
                _suspendableNotifications = suspendableNotifications;
                _suspendableNotifications.SuspendNotifications();
            }
            public void Dispose()
            {
                _suspendableNotifications.ResumeNotifications();
            }
            private readonly ISuspendableNotifications _suspendableNotifications;
        }
        public sealed class Entity: ISuspendableNotifications
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public void SuspendNotifications() {}
            public void ResumeNotifications() {}
        }
        public static class Program
        {
            public static void Main(string[] args)
            {
                Entity entity = new Entity();
                using (new NotificationSuspender(entity))
                {
                    entity.Id = 123454;
                    entity.Name = "Name";
                    entity.Description = "Desc";
                }
            }
        }
    }
                        
