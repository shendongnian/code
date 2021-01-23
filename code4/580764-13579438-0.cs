    using System;
    using System.Configuration;
    
    public static class ConfigurationEncryptor {
    	[Flags]
    	public enum ConfigurationSectionType {
    		ConnectionStrings = 1,
    		ApplicationSettings = 2
    	}
    
    	/// <summary>
    	/// Encrypts the given sections in the current configuration.
    	/// </summary>
    	/// <returns>True is the configuration file was encrypted</returns>
    	public static bool Encrypt(ConfigurationSectionType section) {
    		bool result = false;
    
    		Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    		if (config == null)
    			throw new Exception("Cannot open the configuration file.");
    
    		if (section.HasFlag(ConfigurationSectionType.ConnectionStrings)) {
    			result = result || EncryptSection(config, "connectionStrings");
    		}
    
    		if (section.HasFlag(ConfigurationSectionType.ApplicationSettings)) {
    			result = result || EncryptSection(config, "appSettings");
    		}
    
    		return result;
    	}
    
    	/// <summary>
    	/// Encrypts the specified section.
    	/// </summary>
    	/// <param name="config">The config.</param>
    	/// <param name="section">The section.</param>
    	private static bool EncryptSection(Configuration config, string section) {
    		ConfigurationSection currentSection = config.GetSection(section);
    		if (currentSection == null)
    			throw new Exception("Cannot find " + section + " section in configuration file.");
    		if (!currentSection.SectionInformation.IsProtected) {
    			currentSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
    			config.Save();
    
    			// Refresh configuration
    			ConfigurationManager.RefreshSection(section);
    
    			return true;
    		}
    		return false;
    	}
    }
