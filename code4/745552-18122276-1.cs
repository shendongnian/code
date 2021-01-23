    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    /// <summary>
    /// Class containing the Configuration Storage
    /// </summary>
    [XmlRoot("Configuration")]
    public class ConfigurationStorage
    {
        // The executers.
        private readonly ICollection<string> executers = new List<string>();
        // The IPG prefixes.
        private readonly ICollection<string> ipgPrefixes = new List<string>();
        /// <summary>
        /// Gets the list of executers.
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
        /// Gets the list of IPG prefixes.
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
