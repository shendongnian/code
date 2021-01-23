		<behaviors>
			<serviceBehaviors>
				<behavior>
					<serviceMetadata httpGetEnabled="True"/>
                    <serviceCredentials>
                    <userNameAuthentication
                        userNamePasswordValidationMode="MembershipProvider"
                        membershipProviderName="CustomMembershipProvider" />
                    </serviceCredentials>
				</behavior>
			</serviceBehaviors>
		</behaviors>
