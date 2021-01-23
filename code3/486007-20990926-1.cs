    using System;
    
    using Microsoft.Xrm.Sdk;
    
    /// <summary>
    ///     Base class for all Plugins.
    /// </summary>
    public abstract class PluginBase : IPlugin
    {
        #region Public Properties
    
        /// <summary>
        ///     Gets the entity reference.
        /// </summary>
        /// <value>
        ///     The entity reference.
        /// </value>    
        public EntityReference EntityReference { get; private set; }
    
        /// <summary>
        ///     Gets the plugin context.
        /// </summary>
        /// <value>
        ///     The plugin context.
        /// </value>    
        public PluginContext LocalContext { get; private set; }
    
        #endregion
    
        #region Properties
    
        /// <summary>
        ///     Gets a value indicating whether [ignore plugin].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [ignore plugin]; otherwise, <c>false</c>.
        /// </value>
        /// <created>1/5/2014</created>
        protected virtual bool IgnorePlugin
        {
            get
            {
                return false;
            }
        }
    
        #endregion
    
        #region Public Methods and Operators
    
        /// <summary>
        /// Executes the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>    
        public void Execute(IServiceProvider serviceProvider)
        {
            if (this.IgnorePlugin)
            {
                return;
            }
    
            this.LocalContext = new PluginContext(serviceProvider);
    
            if (!this.LocalContext.PluginExecutionContext.InputParameters.Contains("Target"))
            {
                return;
            }
    
            var entity = this.LocalContext.PluginExecutionContext.InputParameters["Target"] as Entity;
            if (entity != null)
            {
                this.EntityReference = entity.ToEntityReference();
            }
            else
            {
                this.EntityReference =
                    this.LocalContext.PluginExecutionContext.InputParameters["Target"] as EntityReference;
                if (this.EntityReference == null)
                {
                    return;
                }
            }
    
            this.Execute();
        }
    
        /// <summary>
        ///     Executes this instance.
        /// </summary>    
        public abstract void Execute();
    
        #endregion
    }
