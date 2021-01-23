    using Newtonsoft.Json;
    using NodaTime;
    using NodaTime.Serialization.JsonNet; // << Needed for the extension method to appear!
    using System;
    namespace MyProject
    {
        public class MyClass
        {
            private static readonly JsonSerializerSettings _JsonSettings;
            static MyClass()
            {
                _JsonSettings = new JsonSerializerSettings
                {
                    // To be honest, I am not sure these are needed for NodaTime,
                    // but they are useful for `DateTime` objects in other cases.
                    // Be careful copy/pasting these.
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                };
                // Enable NodaTime serialization
                // See: https://nodatime.org/2.2.x/userguide/serialization
                _JsonSettings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            }
            
            // The rest of your code...
        }
    }
