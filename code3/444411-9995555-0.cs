    class ADProperties {
      public const string OBJECTCLASS = "objectClass";
      public const string CONTAINERNAME = "cn";
      public const string LASTNAME = "sn";
      public const string COUNTRYNOTATION = "c";
      public const string CITY = "l";
      public const string STATE = "st";
      public const string TITLE = "title";
      public const string POSTALCODE = "postalCode";
      public const string PHYSICALDELIVERYOFFICENAME = "physicalDeliveryOfficeName";
      public const string FIRSTNAME = "givenName";
      public const string MIDDLENAME = "initials";
      public const string DISTINGUISHEDNAME = "distinguishedName";
      public const string INSTANCETYPE = "instanceType";
      public const string WHENCREATED = "whenCreated";
      public const string WHENCHANGED = "whenChanged";
      public const string DISPLAYNAME = "displayName";
      public const string USNCREATED = "uSNCreated";
      public const string MEMBEROF = "memberOf";
      public const string USNCHANGED = "uSNChanged";
      public const string COUNTRY = "co";
      public const string DEPARTMENT = "department";
      public const string COMPANY = "company";
      public const string PROXYADDRESSES = "proxyAddresses";
      public const string STREETADDRESS = "streetAddress";
      public const string DIRECTREPORTS = "directReports";
      public const string NAME = "name";
      public const string OBJECTGUID = "objectGUID";
      public const string USERACCOUNTCONTROL = "userAccountControl";
      public const string BADPWDCOUNT = "badPwdCount";
      public const string CODEPAGE = "codePage";
      public const string COUNTRYCODE = "countryCode";
      public const string BADPASSWORDTIME = "badPasswordTime";
      public const string LASTLOGOFF = "lastLogoff";
      public const string LASTLOGON = "lastLogon";
      public const string PWDLASTSET = "pwdLastSet";
      public const string PRIMARYGROUPID = "primaryGroupID";
      public const string OBJECTSID = "objectSid";
      public const string ADMINCOUNT = "adminCount";
      public const string ACCOUNTEXPIRES = "accountExpires";
      public const string LOGONCOUNT = "logonCount";
      public const string LOGINNAME = "sAMAccountName";
      public const string SAMACCOUNTTYPE = "sAMAccountType";
      public const string SHOWINADDRESSBOOK = "showInAddressBook";
      public const string LEGACYEXCHANGEDN = "legacyExchangeDN";
      public const string USERPRINCIPALNAME = "userPrincipalName";
      public const string EXTENSION = "ipPhone";
      public const string SERVICEPRINCIPALNAME = "servicePrincipalName";
      public const string OBJECTCATEGORY = "objectCategory";
      public const string DSCOREPROPAGATIONDATA = "dSCorePropagationData";
      public const string LASTLOGONTIMESTAMP = "lastLogonTimestamp";
      public const string EMAILADDRESS = "mail";
      public const string MANAGER = "manager";
      public const string MOBILE = "mobile";
      public const string PAGER = "pager";
      public const string FAX = "facsimileTelephoneNumber";
      public const string HOMEPHONE = "homePhone";
      public const string MSEXCHUSERACCOUNTCONTROL = "msExchUserAccountControl";
      public const string MDBUSEDEFAULTS = "mDBUseDefaults";
      public const string MSEXCHMAILBOXSECURITYDESCRIPTOR = "msExchMailboxSecurityDescriptor";
      public const string HOMEMDB = "homeMDB";
      public const string MSEXCHPOLICIESINCLUDED = "msExchPoliciesIncluded";
      public const string HOMEMTA = "homeMTA";
      public const string MSEXCHRECIPIENTTYPEDETAILS = "msExchRecipientTypeDetails";
      public const string MAILNICKNAME = "mailNickname";
      public const string MSEXCHHOMESERVERNAME = "msExchHomeServerName";
      public const string MSEXCHVERSION = "msExchVersion";
      public const string MSEXCHRECIPIENTDISPLAYTYPE = "msExchRecipientDisplayType";
      public const string MSEXCHMAILBOXGUID = "msExchMailboxGuid";
      public const string NTSECURITYDESCRIPTOR = "nTSecurityDescriptor";
    }
    public class ADUser {
      #region ' Properties '
      public string City { get; private set; }
      public string Company { get; private set; }
      public string Country { get; private set; }
      public string Department { get; private set; }
      public string EmailAddress { get; private set; }
      public string Extension { get; private set; }
      public string Fax { get; private set; }
      public string FirstName { get; private set; }
      public string HomePhone { get; private set; }
      public string LastName { get; private set; }
      public string UserName { get; private set; }
      public string LoginNameWithDomain { get; private set; }
      public string FullName {
       get {
        if (!String.IsNullOrEmpty(FirstName)) {
          if (!String.IsNullOrEmpty(LastName)) {
            return string.Format("{0} {1}", FirstName, LastName);
          } else {
            return FirstName;
          }
        } else if (!String.IsNullOrEmpty(LastName)) {
          return LastName;
        } else {
          return null;
        }
       }
      }
      public string MiddleName { get; private set; }
      public string Mobile { get; private set; }
      public string PostalCode { get; private set; }
      public string StreetAddress { get; private set; }
      public string State { get; private set; }
      public string Title { get; private set; }
      #endregion
      private ADUser(DirectoryEntry directoryUser) {
        FirstName = GetProperty(directoryUser, ADProperties.FIRSTNAME);
        MiddleName = GetProperty(directoryUser, ADProperties.MIDDLENAME);
        LastName = GetProperty(directoryUser, ADProperties.LASTNAME);
        UserName = GetProperty(directoryUser, ADProperties.LOGINNAME);
        string userPrincipalName = GetProperty(directoryUser, ADProperties.USERPRINCIPALNAME);
        string domainAddress = (!String.IsNullOrEmpty(userPrincipalName)) ? userPrincipalName.Split('@')[1] : null;
        string domainName = (!String.IsNullOrEmpty(domainAddress)) ? domainAddress.Split('.')[0] : null;
        LoginNameWithDomain = String.Format(@"{0}\{1}", domainName, UserName);
        StreetAddress = GetProperty(directoryUser, ADProperties.STREETADDRESS);
        City = GetProperty(directoryUser, ADProperties.CITY);
        State = GetProperty(directoryUser, ADProperties.STATE);
        PostalCode = GetProperty(directoryUser, ADProperties.POSTALCODE);
        Country = GetProperty(directoryUser, ADProperties.COUNTRY);
        Company = GetProperty(directoryUser, ADProperties.COMPANY);
        Department = GetProperty(directoryUser, ADProperties.DEPARTMENT);
        HomePhone = GetProperty(directoryUser, ADProperties.HOMEPHONE);
        Extension = GetProperty(directoryUser, ADProperties.EXTENSION);
        Mobile = GetProperty(directoryUser, ADProperties.MOBILE);
        Fax = GetProperty(directoryUser, ADProperties.FAX);
        EmailAddress = GetProperty(directoryUser, ADProperties.EMAILADDRESS);
        Title = GetProperty(directoryUser, ADProperties.TITLE);
      }
      private static string GetProperty(DirectoryEntry userDetail, string propertyName) {
        if (userDetail.Properties.Contains(propertyName)) {
          return userDetail.Properties[propertyName][0].ToString();
        } else {
          return null;
        }
      }
      public static ADUser GetUser(DirectoryEntry directoryUser) {
        return new ADUser(directoryUser);
      }
      public override string ToString() {
        if (!String.IsNullOrEmpty(EmailAddress)) {
          return string.Format("{0} <{1}>", FullName, EmailAddress);
        } else {
          return FullName;
        }
      }
    }
