    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using AutoMapper;
    using NUnit.Framework;
    
    namespace StackOverflowExample.Automapper
    {
        public class Contact
        {
            public Guid ContactId { get; set; }
            public string Name { get; set; }
            public List<Address> Addresses { get; set; }
        }
    
        public partial class Address
        {
            public Guid AddressId { get; set; }
            public Guid ContactId { get; set; }
            public string StreetAddress { get; set; }
        }
    
        [TestFixture]
        public class DatasetRelations
        {
            [Test]
            public void RelationMappingTest()
            {
                //arrange
                var firstContactGuid = Guid.NewGuid();
                var secondContactGuid = Guid.NewGuid();
    
                var addressTable = new DataTable("Addresses");
                addressTable.Columns.Add("AddressId");
                addressTable.Columns.Add("ContactId");
                addressTable.Columns.Add("StreetAddress");
                addressTable.Rows.Add(Guid.NewGuid(), firstContactGuid, "c1 a1");
                addressTable.Rows.Add(Guid.NewGuid(), firstContactGuid, "c1 a2");
                addressTable.Rows.Add(Guid.NewGuid(), secondContactGuid, "c2 a1");
    
                var contactTable = new DataTable("Contacts");
                contactTable.Columns.Add("ContactId");
                contactTable.Columns.Add("Name");
                contactTable.Rows.Add(firstContactGuid, "contact1");
                contactTable.Rows.Add(secondContactGuid, "contact2");
    
                var dataSet = new DataSet();
                dataSet.Tables.Add(contactTable);
                dataSet.Tables.Add(addressTable);
    
                Mapper.CreateMap<IDataReader, Address>();
                Mapper.CreateMap<IDataReader, Contact>().ForMember(c=>c.Addresses, opt=>opt.Ignore());
    
                //act
                var addresses = GetDataFromDataTable<Address>(dataSet, "Addresses");
                var contacts = GetDataFromDataTable<Contact>(dataSet, "Contacts");
                foreach (var contact in contacts)
                {
                    contact.Addresses = addresses.Where(a => a.ContactId == contact.ContactId).ToList();
                }
            }
    
            private IList<T> GetDataFromDataTable<T>(DataSet dataSet, string tableName)
            {
                var table = dataSet.Tables[tableName];
                using (var reader = dataSet.CreateDataReader(table))
                {
                    return Mapper.Map<IList<T>>(reader).ToList();
                }
            }
        }
    } 
