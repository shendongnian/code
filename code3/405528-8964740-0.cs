	public class Attrib
	{
		public virtual long Id { get; set; }
		public virtual string Value { get; set; }
    }
	<class name="Device" table="DEVICES" lazy="false">
    ...
		<bag name="Attributes" table="DEVICE_ATTRIB_VALUES">
			<key column="DEVICE_ID" not-null="true"/>
			<composite-element class="Attrib">
				<property name="Id" column="ATTRIB_ID" type="System.Int64" />
				<property name="Value" column="VALUE" type="System.String"/>
			</composite-element>
		</bag>
    ...
    </class>
