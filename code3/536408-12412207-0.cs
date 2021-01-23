    <dynamicFields hint="raw:AddDynamicFields">
    	<dynamicField type="MyNameSpace.TitleContainsAsterisk,MyBinary" 
    		name="TitleContainsAsterisk" storageType="YES" indexType="TOKENIZED" vectorType="NO" boost="1f" />
    </dynamicFields>
    /// <summary>
    /// Field Configuration (for the indexer) to index the if there is an asterisk in the title
    /// </summary>
    public class TitleContainsAsterisk: BaseDynamicField {
        public override string ResolveValue(Item item) {
            string myTitleField = "My Title Field";
            bool containsAsterisk = item.Fields[myTitleField].Value.Contains("*");
            return containsAsterisk ? "1" : "0";
    	}
    }
