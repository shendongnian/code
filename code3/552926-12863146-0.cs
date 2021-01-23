    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    namespace WebActivator
    {
      public static class HostInformation
      {
        private static readonly string[] _knownDevEnvironments = new[] { 
          "devenv",
          "microsoft.visualstudio.web.host"
        };
        private static Lazy<bool> _isDevelopmentEnvironment = new Lazy<bool>(
          () => _knownDevEnvironments.Any(
            s => s.Equals(Process.GetCurrentProcess().ProcessName,
                          StringComparison.OrdinalIgnoreCase)
          ));
        /// <summary>
        /// Returns true if the current hosting environment is a known 
        /// development environment instead of a web server or similar.
        /// 
        /// This is used to decide whether or not to actually run 
        /// pre-application-start methods which are undesirable to 
        /// run in the development environment.
        /// </summary>
        /// <returns></returns>
        public static bool IsDevelopmentEnvironment
        {
          get
          {
            return _isDevelopmentEnvironment.Value;
          }
        }
      }
    }
