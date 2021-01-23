    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    namespace My.Name.Space
    {
        public class MyEntity
        {
            public int Id { get; set; }
            public Dictionary<string, EmployeeLeaveEntitlement> LeaveEntitlementDetails { get; set; } 
        }
        public class MyEntityConfiguration : IEntityTypeConfiguration<MyEntity>
        {
            public void Configure(EntityTypeBuilder<MyEntity> builder)
            {
                builder.ToTable("MyEntity");
                builder.HasKey(e => e.Id);
                builder
                .Property(e => e.LeaveEntitlementDetails)
                .IsRequired()
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => v == null
                        ? new Dictionary<string, EmployeeLeaveEntitlement>() // fallback
                        : JsonConvert.DeserializeObject<Dictionary<string, EmployeeLeaveEntitlement>>(v)
                );
            }
        }
    }
