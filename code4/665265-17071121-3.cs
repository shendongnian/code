    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Markup;
    namespace WpfApplication7
    {
    	[MarkupExtensionReturnType(typeof(Style))]
    	public class CombiStyleExtension : MarkupExtension
    	{
    		/// <summary>
    		/// Set space-separated style names i.e. "size16 grey verdana".
    		/// </summary>
    		public string Names { private get; set; }
    
    		public override object ProvideValue(IServiceProvider serviceProvider)
    		{
    			return Names.Split(new[] { ' ' })
    						.Select(x => Application.Current.TryFindResource(x)
    							as Style)
    						.Aggregate(new Style(), RecursivelyMergeStyles);
    		}
    		private static Style RecursivelyMergeStyles(Style accumulator,
                                                        Style next)
    		{
    			if(accumulator == null || next == null)
    				return accumulator;
    			if(next.BasedOn != null)
    				RecursivelyMergeStyles(accumulator, next.BasedOn);
    			MergeStyle(accumulator, next);
    			return accumulator;
    		}
    		private static void MergeStyle(Style targetStyle, Style sourceStyle)
    		{
    			if(targetStyle == null || sourceStyle == null)
    			{
    				return;
    			}
        		targetStyle.TargetType = sourceStyle.TargetType;
			
	    		// Merge the Setters...
	    		foreach(var setter in sourceStyle.Setters)
	    			targetStyle.Setters.Add(setter);
	    		// Merge the Triggers...
	    		foreach(var trigger in sourceStyle.Triggers)
	    			targetStyle.Triggers.Add(trigger);
	    	}
	    }
    }
