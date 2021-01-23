    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.DirectoryServices.Protocols;
    using System.Data.SqlClient;
    using System.Data;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Text.RegularExpressions;
    using log4net;
    using log4net.Config;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.IO;
    namespace ADImportPlugIn {
        public class ADImport : PlugIn
        {
            private ADDataSet myADUsers = null;
            LdapConnection _LDAP = null;
            MDBDataContext mdb = null;
            private Orgs myOrgs = null;
        
            public override void JustGronkIT()
            {
            	string filter = "(&(objectCategory=person)(objectClass=user)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))";
        	    string tartgetOU = @"yourdomain.com";
        	    string[] attrs = {"sAMAccountName","givenName","sn","initials","description","userPrincipalName","distinguishedName",
                "extentionAttribute6","departmentNumber","wwwHomePage","manager","extensionName", "mail","telephoneNumber"};
                using (_LDAP = new LdapConnection(Properties.Settings.Default.Domain))
                {
            	    myADUsers = new ADDataSet();
            	    myADUsers.ADUsers.MinimumCapacity = 60000;
            	    myADUsers.ADUsers.CaseSensitive = false;
            	
            	    try
            	    {
            		    SearchRequest request = new SearchRequest(tartgetOU, filter, System.DirectoryServices.Protocols.SearchScope.Subtree, attrs);
            		    PageResultRequestControl pageRequest = new PageResultRequestControl(5000);
            		    request.Controls.Add(pageRequest);
            		    SearchOptionsControl searchOptions = new SearchOptionsControl(System.DirectoryServices.Protocols.SearchOption.DomainScope);
            		    request.Controls.Add(searchOptions);
            		
            		    while (true)
            		    {
            			    SearchResponse searchResponse = (SearchResponse)_LDAP.SendRequest(request);
            			    PageResultResponseControl pageResponse = (PageResultResponseControl)searchResponse.Controls[0];
            			    foreach (SearchResultEntry entry in searchResponse.Entries)
            			    {
                                string _myUserid="";
                                string _myUPN="";
            				    SearchResultAttributeCollection attributes = entry.Attributes;
            				    foreach (DirectoryAttribute attribute in attributes.Values)
            				    {
            					    if (attribute.Name.Equals("sAMAccountName"))
            					    {
            						    _myUserid = (string)attribute[0] ?? "";
            						    _myUserid.Trim();
            					    }
            					    if (attribute.Name.Equals("userPrincipalName"))
            					    {
            						    _myUPN = (string)attribute[0] ?? "";
            						    _myUPN.Trim();
                                    }
                                    //etc with each datum you return from AD
            				}//foreach DirectoryAttribute
            				//do something with all the above info, I put it into a dataset
            			    }//foreach SearchResultEntry
            			    if (pageResponse.Cookie.Length == 0)//check and see if there are more pages
							    break; //There are no more pages
                            pageRequest.Cookie = pageResponse.Cookie;
                       }//while loop
                  }//try
                  catch{}
        	    }//using _LDAP
            }//JustGronkIT method
        }//ADImport class
    } //namespace
