    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    /// <summary>
    /// Class containing the Configuration Storage
    /// </summary>
    [XmlRoot("Configuration")]
    public class ConfigurationStorage
    {
        private readonly List<string> executers = new List<string>();
        private readonly List<string> ipgPrefixes = new List<string>();
        /// <summary>
        /// Gets or sets the list of executers.
        /// </summary>
        [XmlArray("Executers")]
        [XmlArrayItem("Executer")]
        public ICollection<string> Executers
        { 
            get
            {
                return this.executers;
            }
        }
        /// <summary>
        /// Gets or sets the list of IPG prefixes.
        /// </summary>
        [XmlArray("IpgPrefixes")]
        [XmlArrayItem("IpgPrefix")]
        public ICollection<string> IpgPrefixes
        { 
            get
            {
                return this.ipgPrefixes;
            }
        }
    }
