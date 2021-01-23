    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    namespace testEF {
        class Program {
            static void Main(string[] args) {
                using ( EFContext efc = new EFContext() ) {
                    var AHAddress = new Address {
                        AddressId = 1,
                        HouseNumber = "150",
                        Street = "street",
                    };
                    var AHNominee = new Nominee {
                        NomineeId = 1,
                        Address = new List<Address>() { 
                            AHAddress
                        }};                
                    var accountHolder = new AccountHolder() {
                        Address = new List<Address>() { 
                            AHAddress
                        },
                        Nominee = AHNominee
                    };
                    efc.Holders.Add(accountHolder);
                    efc.SaveChanges();
                    foreach (AccountHolder ah in efc.Holders) {
                        Console.WriteLine("{0} -> {1}", ah.AccountHolderId, ah.Nominee.NomineeId);
                    }
                };
            }
        }
        public partial class AccountHolder {
            public int AccountHolderId { get; set; }
            public virtual List<Address> Address { get; set; }
            public virtual Nominee Nominee { get; set; }
        }
        public partial class Nominee {
            public int NomineeId { get; set; }
            public virtual List<Address> Address { get; set; }
        }
        public partial class Address {
            public int AddressId { get; set; }
            public String HouseNumber { get; set; }
            public String Street { get; set; }
            public int AccountHolderId { get; set; }
            public AccountHolder AccountHolder { get; set; }
            public int NomineeId { get; set; }
            public Nominee Nominee { get; set; }
        }
        public class EFContext : DbContext {
            public IDbSet<AccountHolder> Holders { get; set; }
            public EFContext()
                : base() {
                Database.SetInitializer<EFContext>(new DropCreateDatabaseAlways<EFContext>());
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder) {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<AccountHolder>().HasOptional(p => p.Nominee)
                                                .WithRequired()
                                                .WillCascadeOnDelete(false);
                modelBuilder.Entity<Address>().HasRequired(p => p.AccountHolder)
                                              .WithMany(p => p.Address)
                                              .HasForeignKey(p => p.AccountHolderId)
                                              .WillCascadeOnDelete();
                modelBuilder.Entity<Address>().HasRequired(p => p.Nominee)
                                              .WithMany(p => p.Address)
                                              .HasForeignKey(p => p.NomineeId)
                                              .WillCascadeOnDelete();
            }
        }    
    }
