    public class User
    {
        public virtual long Id { get; set; }
        public virtual ICollection<FriendshipRequest> InitiatedRequests { get; private set; }
        public virtual ICollection<FriendshipRequest> ReceivedRequests { get; private set; }
        public virtual IEnumerable<User> Friends
        {
            get {
                return  (from fr in InitiatedRequests
                         where fr.Accepted
                         select fr.Friend)
                        .Concat(
                         from fr in ReceivedRequests
                         where fr.Accepted
                         select fr.Initiator);
            }
        }
        public User()
        {
            InitiatedRequests = new HashSet<FriendshipRequest>();
            ReceivedRequests = new HashSet<FriendshipRequest>();
        }
    }
    public class FriendshipRequest
    {
        public virtual User Initiator { get; set; }
        public virtual User Friend { get; set; }
        public virtual bool Accepted { get { return Added != default(DateTime); } }
        public virtual DateTime Added { get; set; }
        // override Equals
    }
    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2">
      <class name="Namespace.Data.Entities.User,Namespace.Data.Entities" table="`User`">
        ...
        <set name="InitiatedRequests" cascade="all" table="FriendshipRequests">
          <key column="`UserID`" />
          <composite-element>
            <property type="DateTime" name="Added" column="`AddedDateTime`" />
            <parent name="Initiator" />
            <many-to-one name="Friend" column="`FriendUserID`" not-null="true" />
          </composite-element>
        </bag>
        <set name="ReceivedRequests" cascade="all" table="FriendshipRequests" inverse="true">
          <key column="`FriendUserID`" />
          <composite-element>
            <property type="DateTime" name="Added" column="`AddedDateTime`" />
            <parent name="Friend" />
            <many-to-one name="Initiator" column="`UserID`" not-null="true" />
          </composite-element>
        </bag>
      </class>
    </hibernate-mapping>
