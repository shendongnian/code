Since you are accessing the metadata outside of "normal" MVC validation or display templates, you will need to register the TypeDescription yourself.
    [MetadataType(typeof(RosterMetadata))]
    public partial class DespatchRoster
    {
    	static DespatchRoster() {
    		TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(typeof(DespatchRoster), typeof(RosterMetadata)), typeof(DespatchRoster));
    	}
    }
    
    public class RosterMetadata
    {
        [Display(Name="Slappy")]
        public string despatchDay { get; set; }
    }
Then to access the Display Name we need to enumerate the properties using the TypeDescriptor not the normal PropertyInfo method.
    <% PropertyDescriptorCollection currentFields = TypeDescriptor.GetProperties(typeof(DespatchRoster)); %>
    
    <% foreach (PropertyDescriptor pd in currentFields){ %>
      <% string name = pd.Attributes.OfType<DisplayAttribute>().Select(da => da.Name).FirstOrDefault(); %>
      <li class="<%= name %>"><%= name %></li>
    <%} %>
