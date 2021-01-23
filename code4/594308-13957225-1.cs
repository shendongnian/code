    using System;
    using System.Diagnostics.Contracts;
    
    using Project.Contracts.Model.Accounts;
    using Project.Contracts.Services;
    /// <summary>
    /// Data access for accounts.
    /// </summary>
    [ContractClass(typeof(AccountRepositoryContract))]
    public interface IAccountRepository
    {
        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The user, or <c>null</c> if user not found.</returns>
        [Pure]
        User GetUserById(int userId);
    }
    /// <summary>
    /// Contract class for <see cref="IAccountRepository"/>.
    /// </summary>
    [ContractClassFor(typeof(IAccountRepository))]
    internal abstract class AccountRepositoryContract : IAccountRepository
    {
        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>
        /// The user, or <c>null</c> if user not found.
        /// </returns>
        public User GetUserById(int userId)
        {
            Contract.Requires<ArgumentException>(userId > 0);
            return null;
        }
    }
