	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Xml.Linq;
	namespace CreateMSBuildProject
	{
		/// <summary>Encapsulates a ".csproj" file.</summary>
		
		sealed class CSProj
		{
			/// <summary>Encapsulates information about a particular build configuration.</summary>
			public sealed class BuildConfiguration
			{
				public BuildConfiguration(XElement configuration)
				{
					// ReSharper disable PossibleNullReferenceException
					OutputPath             = configuration.Element(_ns + "OutputPath").Value;
					WarningLevel           = warningLevel(configuration);
					CodeAnalysisRuleset    = configuration.Element(_ns + "CodeAnalysisRuleSet").Value;
					TreatWarningsAsErrors  = isTrue(configuration.Element(_ns + "TreatWarningsAsErrors"));
					IsCodeAnalysisEnabled  = isTrue(configuration.Element(_ns + "RunCodeAnalysis"));
					IsCodeContractsEnabled = isTrue(configuration.Element(_ns + "CodeContractsEnableRuntimeChecking"));
					// ReSharper restore PossibleNullReferenceException
				}
				public bool IsDebug
				{
					get
					{
						return (string.Compare(OutputPath, "bin\\debug\\", StringComparison.OrdinalIgnoreCase) == 0);
					}
				}
				public bool IsRelease
				{
					get
					{
						return(string.Compare(OutputPath, "bin\\release\\", StringComparison.OrdinalIgnoreCase) == 0);
					}
				}
				static bool isTrue(XElement element) // Defaults to false if element is null.
				{
					return (element != null) && (string.Compare(element.Value, "true", StringComparison.OrdinalIgnoreCase) == 0);
				}
				static int warningLevel(XElement element) // Defaults to 4 if not set.
				{
					var level = element.Element(_ns + "WarningLevel");
					if (level != null)
						return int.Parse(level.Value);
					else
						return 4; // Default warning level is 4.
				}
				public readonly string OutputPath;
				public readonly string CodeAnalysisRuleset;
				public readonly bool   IsCodeAnalysisEnabled;
				public readonly bool   TreatWarningsAsErrors;
				public readonly bool   IsCodeContractsEnabled;
				public readonly int    WarningLevel;
			}
			/// <summary>Encapsulates information about a referenced assembly.</summary>
			public sealed class AssemblyReference
			{
				public AssemblyReference(XElement reference)
				{
					Include = reference.Attribute("Include").Value.Split(',')[0]; // Get rid of stuff after the first ","
					var hintElem = reference.Element(_ns+"HintPath");
					if (hintElem != null)
						HintPath = hintElem.Value;
					else
						HintPath = "";
				}
				public readonly string HintPath;
				public readonly string Include;
			}
			/// <summary>Constructor.</summary>
			public CSProj(string csprojFilePath)
			{
				if (!isValidProjFilePath(csprojFilePath))
					throw new ArgumentOutOfRangeException("csprojFilePath", csprojFilePath, "File does not exist, or filename does not end with '.csproj'.");
				// ReSharper disable PossibleMultipleEnumeration
				XDocument doc = XDocument.Load(csprojFilePath);
				var propertyGroups = getPropertyGroups(doc);
				_projectFilePath              = csprojFilePath;
				_outputType                   = getOutputType(propertyGroups);
				_assemblyName                 = getAssemblyName(propertyGroups);
				_targetFrameworkVersion       = getTargetFrameworkVersion(propertyGroups);
				_projectDependencies          = getProjectDependencies(doc);
				_targetFrameworkProfile       = getTargetFrameworkProfile(doc);
				_xmlDocumentationFiles        = getXmlDocumentationFiles(doc);
				_buildConfigurations          = getBuildConfigurations(doc);
				_assemblyReferences           = getAssemblyReferences(doc);
				_anyStaticCodeAnalysisEnabled = getAnyStaticCodeAnalysisEnabled(doc);
				_platformTargets              = getPlatformTargets(doc);
				// ReSharper restore PossibleMultipleEnumeration
			}
			#region Properties
			/// <summary>The project output type, e.g. "WinExe" or "Library".</summary>
			public string OutputType { get { return _outputType; }  }
			/// <summary>The project's output assembly name.</summary>
			public string AssemblyName { get { return _assemblyName; } }
			/// <summary>The target framework version, or 0.0 if not set.</summary>
			
			public double TargetFrameworkVersion { get { return _targetFrameworkVersion; } }
			/// <summary>The project dependencies - not to be confused with assembly references!</summary>
			public IEnumerable<string> ProjectDependencies { get { return _projectDependencies; } }
			public IEnumerable<string> XmlDocumentationFiles { get { return _xmlDocumentationFiles; } }
			public IEnumerable<BuildConfiguration> BuildConfigurations { get { return _buildConfigurations; } }
			public string TargetFrameworkProfile { get { return _targetFrameworkProfile; } }
			public IEnumerable<AssemblyReference> AssemblyReferences { get { return _assemblyReferences; } }
			public bool AnyStaticCodeAnalysisEnabled { get { return _anyStaticCodeAnalysisEnabled; } }
			public string ProjectFilePath { get { return _projectFilePath; } }
			public string[] PlatformTargets { get { return _platformTargets; } }
			#endregion Properties
			//—————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
			static string[] getPlatformTargets(XDocument doc) 
			{
				var result = (from item in doc.Descendants(_ns + "PlatformTarget") select item.Value).ToArray();
				if (result.Length > 0)
					return result;
				else
					return new []{"AnyCPU"}; // If "PlatformTarget" is not specified, it defaults to "AnyCPU".
			}
			static IEnumerable<XElement> getPropertyGroups(XDocument doc)
			{
				// ReSharper disable PossibleNullReferenceException
				return doc.Element(_ns+"Project").Elements(_ns+"PropertyGroup");
				// ReSharper restore PossibleNullReferenceException
			}
			static string getOutputType(IEnumerable<XElement> propertyGroups)
			{
				return propertyGroups.Elements(_ns+"OutputType").First().Value;
			}
			static string getAssemblyName(IEnumerable<XElement> propertyGroups)
			{
				return propertyGroups.Elements(_ns+"AssemblyName").First().Value;
			}
			static double getTargetFrameworkVersion(IEnumerable<XElement> propertyGroups)
			{
				var targetFrameworkVersion = propertyGroups.Elements(_ns+"TargetFrameworkVersion").FirstOrDefault();
				if (targetFrameworkVersion != null)
					return double.Parse(targetFrameworkVersion.Value.Substring(1)); // Skip first character, which is "v"; eg like "v3.5"
				else
					return 0;
			}
			static string[] getProjectDependencies(XDocument doc)
			{
				return 
				(
					from item in doc.Descendants(_ns + "ProjectReference")
					select item.Attribute("Include").Value
				)
				.ToArray();
			}
			static string getTargetFrameworkProfile(XDocument doc)
			{
				var targetFrameworkProfile = doc.Descendants(_ns + "TargetFrameworkProfile").FirstOrDefault();
				if (targetFrameworkProfile != null)
					return targetFrameworkProfile.Value;
				else
					return "";
			}
			static string[] getXmlDocumentationFiles(XDocument doc)
			{
				return
				(
					from item in doc.Descendants(_ns+"DocumentationFile")
					select item.Value
				)
				.ToArray();
			}
			static BuildConfiguration[] getBuildConfigurations(XDocument doc)
			{
				var configGroups = from item in doc.Descendants(_ns+"PropertyGroup")
								   where item.Descendants(_ns+"OutputPath").Any()
								   select new BuildConfiguration(item);
				return configGroups.ToArray();
			}
			static AssemblyReference[] getAssemblyReferences(XDocument doc)
			{
				var references = from item in doc.Descendants(_ns + "Reference")
								 select new AssemblyReference(item);
				return references.ToArray();
			}
			static bool getAnyStaticCodeAnalysisEnabled(XDocument doc)
			{
				return doc.Descendants(_ns + "CodeContractsRunCodeAnalysis")
					.Where(item => item.Attribute("Condition") == null) // Some of these have a "Condition" attribute, which is OK.
					.Any(item => string.Compare(item.Value, "true", StringComparison.OrdinalIgnoreCase) == 0);
			}
			static bool isValidProjFilePath(string projFilePath)
			{
				return 
				(
					!string.IsNullOrWhiteSpace(projFilePath) 
					&& (projFilePath.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase) || projFilePath.EndsWith(".vbproj", StringComparison.OrdinalIgnoreCase))
					&& File.Exists(projFilePath)
				);
			}
			static readonly XNamespace _ns = "http://schemas.microsoft.com/developer/msbuild/2003";
			readonly bool _anyStaticCodeAnalysisEnabled;
			readonly string _projectFilePath;
			readonly string _outputType;
			readonly string _assemblyName;
			readonly string _targetFrameworkProfile;
			readonly double _targetFrameworkVersion;
			readonly string[] _projectDependencies;
			readonly string[] _xmlDocumentationFiles;
			readonly string[] _platformTargets;
			readonly BuildConfiguration[]     _buildConfigurations;
			readonly AssemblyReference[] _assemblyReferences;
		}
	}
