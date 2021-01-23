    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    namespace Generate.Test
    {
    	/// <summary>
    	/// The configuration class.
    	/// </summary>
    	[Serializable, XmlRoot("generate-configuration")]
    	public class Configuration : ISerializable
    	{
    		#region Fields
    
    		private string inputPath  = string.Empty;
    		private string outputPath = string.Empty;
    		private int    maxCount   = 0;
    
    		#endregion
    
    		#region Constructors
    
    		/// <summary>
    		/// Initializes a new instance of the <see cref="Configuration" /> class.
    		/// </summary>
    		public Configuration()
    		{
    		}
    
    		#endregion
    
    		#region Properties
    		/// <summary>
    		/// Gets or sets the output path.
    		/// </summary>
    		/// <value>
    		/// The output path.
    		/// </value>
    		[XmlElement("output-path")]
    		public string OutputPath
    		{
    			get { return this.outputPath; }
    			set { this.outputPath = value; }
    		}
    
    		/// <summary>
    		/// Gets or sets the input path.
    		/// </summary>
    		/// <value>
    		/// The input path.
    		/// </value>
    		[XmlElement("input-path")]
    		public string InputPath
    		{
    			get { return this.inputPath; }
    			set { this.inputPath = value; }
    		}
    
    		/// <summary>
    		/// Gets or sets the max count.
    		/// </summary>
    		/// <value>
    		/// The max count.
    		/// </value>
    		[XmlElement("max-count")]
    		public int MaxCount
    		{
    			get { return this.maxCount; }
    			set { this.maxCount = value; }
    		}
    		#endregion
    
    		#region ISerializable Members
    
    		/// <summary>
    		/// Gets the object data.
    		/// </summary>
    		/// <param name="info">The info.</param>
    		/// <param name="context">The context.</param>
    		/// <exception cref="System.ArgumentNullException">thrown when the info parameter is empty.</exception>
    		public void GetObjectData(SerializationInfo info, StreamingContext context)
    		{
    			if (info == null)
    				throw new System.ArgumentNullException("info");
    
    			info.AddValue("output-path", this.OutputPath);
    			info.AddValue("input-path", this.InputPath);
    			info.AddValue("max-count", this.MaxCount);
    		}
    
    		#endregion
    	}
    }
